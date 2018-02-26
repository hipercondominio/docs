/// <reference path="Core.js" />

Core.Components = {
	/**
	 * Faz a prepara��o de atributos de um componente para corresponder a propriedades, analisando vetores, objetos e literais.
	 * @param {object} ref - Objeto por refer�ncia.
	 */
	importProperties: function (ref) {
		for (attr of ref.attributes) {
			if (Core.Components[ref.tagName].Descriptor.properties[attr.name] == "array") {
				let arr = attr.nodeValue.split(",");
				ref[attr.name] = arr.map((el) => {
					if (!jQuery.isNumeric(el)) {
						return `${el}`;
					} else {
						return el;
					}
				});
			} else {
				ref[attr.name] = attr.nodeValue;
			}
		}

	}

}
