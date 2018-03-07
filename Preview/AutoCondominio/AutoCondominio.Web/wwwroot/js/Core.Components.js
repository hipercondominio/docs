/// <reference path="Core.js" />

Core.Components = {
	/**
	 * //todo: n�o usado
	 * Fazer a pesquisa caso insensitivo de um componente.
	 * @method
	 * @memberof Core.Components
	 * @argument {string} tag Tag do componente.
	 * @returns {object} Objeto que tem os dados do componente.
	 * */
	findComponent: function (tag) {
		tag = tag.split(":")[1].toLowerCase();
		for (el of Object.getOwnPropertyNames(Core.Components)) {
			if (el.toLowerCase() == tag)
				return el;
		}
	},
	/**
	 * //todo: n�o usado
	 * Faz a prepara��o de atributos de um componente para corresponder a propriedades, analisando vetores, objetos e literais.
	 * @method
	 * @memberof Core.Components
	 * @argument {object} ref Objeto por refer�ncia.
	 */
	importProperties: function (ref) {
		for (attr of ref.attributes) {
			//todas as propriedades est�o rastre�veis //hack: necess�rio? seria poss�vel apontar quais propriedades geram mudan�a de vis�o do componente
			let key = attr.name.toCamelCase();
			//hack: poss�vel melhorar as propriedades com underline para que sejam realmente privadas?

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
