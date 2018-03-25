window.setTimeout(() => {
	for (ext in Cks.Extensions) {
		Cks.Extensions[ext].apply();
	}
	Cks.installAll();
	Cks.transformAll();
});

var Cks = {
	/**
	 * Mapeamento de eventos de um objeto para outro.
	 * @param {object} from  Obrigat�rio. Refer�ncia objeto que origina o evento.
	 * @param {string} name  Obrigat�rio. Nome do evento.
	 * @param {object} to  Obrigat�rio. Refer�ncia objeto que executa o evento.
	 * @returns {never}
	 */
	event: (from, name, to) => {
		$(from).on(name, (e) => {
			var events = jQuery._data(to, "events")[name];
			if (events) {
				for (let event of events) {
					event.handler(e);
				}
			}
		});
		/* //hack: como tratar eventos definidos na propriedade on...
		(function () {
			var _prop;
			Object.defineProperty(to, "on" + name, {
				get: () => {
					return _prop;
				},
				set: (v) => {
					_prop = v;
					debugger 
					if (v) {
						$(from).on(name, v);
					} else {
						$(from).off(name);
					}
				},
			});
		})();
		*/
	},

	/**
	 * Mapeamento de atributos para propriedades.
	 * @param {object} comp  Obrigat�rio. Refer�ncia para o componente trabalhado.
	 * @param {string} name  Obrigat�rio. Nome do atributo.
	 * @param {object} type  Obrigat�rio. Tipo do atributo, como String, Boolean, Number.
	 * @param {any} def  Opcional. Valor padr�o, caso n�o seja obtido o valor do atributo.
	 * @returns {never}
	 */
	attr: (comp, name, type, def) => {
		var namecc = name.toCamelCase();
		var attrv = comp.getAttribute(name);
		if (attrv == undefined)  //tentar com namespace
			attrv = comp.getAttribute("cks:" + name);

		if (attrv != undefined) {
			switch (type) {
				case String:
					comp[namecc] = attrv;
					break;
				case Number:
					comp[namecc] = Number.parse(attrv);
					break;
				case Boolean:
					comp[namecc] = true;
					break;
				case Array:
					comp[namecc] = attrv.split(",");
					break;
			}
		} else if (def) {  //valor padr�o, se informado
			comp[namecc] = def;
		}
	},

	/**
	 * Insere um conte�do externo que est� na url de 'href' dentro de um elemento selecionado com 'target' opcionalmente filtrado por 'filter'.
	 * @param {string} href  Obrigat�rio. Url de origem dos dados.
	 * @param {string} target  Opcional. Seletor de destino dos dados obtidos.
	 * @param {string} filter  Opcional. Seletor que delimita a por��o dos dados que ser� inserida.
	 * @returns {string}  Dados recebidos.
	 */
	loadSrc: async (href, target = "BODY", filter) => {
		var contents = await jQuery.get(href);
		if (filter) {
			var parser = new DOMParser();
			var doc = parser.parseFromString(contents, "text/html");
			contents = $(filter, $(doc))[0].outerHTML;
		}
		$(target).html(contents);
		return contents;
	},

	/**
	 * Faz a instala��o de todos os componentes utilizados.
	 */
	installAll: () => {
		for (let el in Cks.Components) {
			let f;
			if (func = Cks.Components[el].install) {  //fun��o comum
				func();
			}
		}
	},

	/**
	 * Faz a instala��o de todos os componentes utilizados.
	 */
	transformAll: (selector = "body") => {
		for (let el in Cks.Components) {
			let f;
			if (func = Cks.Components[el].transform) {  //fun��o comum
				func(selector);
			}
		}
	},

	/**
	 * Faz a transforma��o de todos os componentes em uma determinada �rea.
	 */
	transformAll: (selector = "body") => {
		for (let el in Cks.Components) {
			let f;
			if (func = Cks.Components[el].transform) {  //fun��o comum
				func(selector);
			}
		}
	},

	/**
	 * //todo: n�o usado
	 * Fazer a pesquisa caso insensitivo de um componente.
	 * @method
	 * @memberof Cks.Components
	 * @argument {string} tag Tag do componente.
	 * @returns {object} Objeto que tem os dados do componente.
	 */
	findComponent: (tag) => {
		tag = tag.split(":")[1].toLowerCase();
		for (el of Object.getOwnPropertyNames(Cks.Components)) {
			if (el.toLowerCase() == tag)
				return el;
		}
	},

	/**
	 * //todo: n�o usado
	 * Faz a prepara��o de atributos de um componente para corresponder a propriedades, analisando vetores, objetos e literais.
	 * @method
	 * @memberof Cks.Components
	 * @argument {object} ref Objeto por refer�ncia.
	 */
	importProperties: (ref) => {
		for (attr of ref.attributes) {
			//todas as propriedades est�o rastre�veis //hack: necess�rio? seria poss�vel apontar quais propriedades geram mudan�a de vis�o do componente
			let key = attr.name.toCamelCase();
			//hack: poss�vel melhorar as propriedades com underline para que sejam realmente privadas?

			let tag = this.findComponent(ref.tagName);
			switch (Cks.Components[tag].Descriptor.properties[key]) {
				case "array":
					let arr = attr.nodeValue.split(",");
					ref[attr.name] = arr.map((el) => {
						if (!jQuery.isNumeric(el)) {
							return el.toString();
						} else {
							return el;
						}
					});
					break;
				case "boolean":
					ref[key] = attr.nodeValue == "" ? true : false;
					break;
				default:
					ref[key] = attr.nodeValue;
			}
		}

	},
};








	/////**
	//// * Faz a importa��o dos atributos padr�o html para as propriedades do componente.
	//// * @param {object} comp  Obrigat�rio. Refer�ncia para o componente.
	//// * @param {string} selector  Obrigat�rio. Seletor css para o n� interno que ser� sincronizado.
	//// */
	////import: (comp, selector) => {
	////	var mapper = Cks.Components[comp.component].map;
	////	var target = $(selector)[0];
	////	for (let member of mapper.attributes) {
	////		var attr = comp.attributes[member];
	////		if (attr != undefined) {
	////			switch (typeof (target[attr.name])) {
	////				case "string":
	////					target[attr.name] = attr.value;
	////					break;
	////				case "number":
	////					target[attr.name] = eval(attr.value);
	////					break;
	////				case "boolean":
	////					target[attr.name] = true;
	////					break;
	////			}
	////		}
	////	}
	////},

	/////**
	//// * Faz o mapeamento das propriedades de um componente para um objeto interno, sincronizando propriedades, m�todos e eventos.
	//// * @param {object} comp  Obrigat�rio. Refer�ncia para o componente.
	//// * @param {string} selector  Obrigat�rio. Seletor css para o n� interno que ser� sincronizado.
	//// */
	////map: (comp, selector) => {
	////	var mapper = Cks.Components[comp.component].map;
	////	var target = $(selector)[0];
	////	if (mapper.attributes) {
	////		for (let member of mapper.attributes) {
	////			Object.defineProperty(comp, member, {
	////				get: () => {
	////					return target[member];
	////				},
	////				set: (v) => {
	////					target[member] = v;
	////				},
	////			});
	////		}
	////	}
	////	if (mapper.methods) {
	////		for (let member of mapper.methods) {
	////			comp[member] = (...args) => {
	////				target[member].call(args);
	////			};
	////		}
	////	}
	////	if (mapper.events) {
	////		for (let member of mapper.events) {
	////			target[member] = (e) => {
	////				if (comp[member])
	////					comp[member](e);
	////			};
	////		}
	////	}
	////},
