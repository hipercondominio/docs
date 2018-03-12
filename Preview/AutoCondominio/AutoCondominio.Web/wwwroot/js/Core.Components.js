/// <reference path="Core.js" />

Core.Components = {
	/**
	 * Faz a instalação de todos os componentes utilizados.
	 * */
	installAll: () => {
		for (let el in Core.Components) {
			let f;
			if (func = Core.Components[el].install) {  //função comum
				func();
			}
		}
	},

	/**
	 * Faz a instalação de todos os componentes utilizados.
	 * */
	transformAll: (selector = "body") => {
		for (let el in Core.Components) {
			let f;
			if (func = Core.Components[el].transform) {  //função comum
				func(selector);
			}
		}
	},

	/**
	 * Faz a transformação de todos os componentes em uma determinada área.
	 * */
	transformAll: (selector = "body") => {
		for (let el in Core.Components) {
			let f;
			if (func = Core.Components[el].transform) {  //função comum
				func(selector);
			}
		}
	},

	/**
	 * //todo: não usado
	 * Fazer a pesquisa caso insensitivo de um componente.
	 * @method
	 * @memberof Core.Components
	 * @argument {string} tag Tag do componente.
	 * @returns {object} Objeto que tem os dados do componente.
	 * */
	findComponent: (tag) => {
		tag = tag.split(":")[1].toLowerCase();
		for (el of Object.getOwnPropertyNames(Core.Components)) {
			if (el.toLowerCase() == tag)
				return el;
		}
	},

	/**
	 * //todo: não usado
	 * Faz a preparação de atributos de um componente para corresponder a propriedades, analisando vetores, objetos e literais.
	 * @method
	 * @memberof Core.Components
	 * @argument {object} ref Objeto por referência.
	 */
	importProperties: (ref) => {
		for (attr of ref.attributes) {
			//todas as propriedades estão rastreáveis //hack: necessário? seria possível apontar quais propriedades geram mudança de visão do componente
			let key = attr.name.toCamelCase();
			//hack: possível melhorar as propriedades com underline para que sejam realmente privadas?

			let tag = this.findComponent(ref.tagName);
			switch (Core.Components[tag].Descriptor.properties[key]) {
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

}

window.setTimeout(() => {
	Core.Components.installAll();
	Core.Components.transformAll();
});
