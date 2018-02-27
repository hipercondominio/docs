/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.select = {
	/**
	 * Descri��o da estrutura
	 * */
	Descriptor: {
		tag: "select",
		parent: null,
		children: [{ Option: { ocurrences: { min: 1 } } }, { OptGroup: {} }],
		properties: {
			$import : "select",
			helpDisabled: "string",
			hide: "boolean",
		},
	},
	/**
	 * Faz a configura��o inicial do plugin para os componentes do mesmo tipo.
	 * */
	install: function () {
		
	},
	/**
	 * Efetua o processamento das tags de componente.
	 * @param selector: Seletor css onde ocorrer� a varredura de transforma��o.
	 * */
	transform: function (selector) {
		$("select", selector).addClass("form-control");

	}
}

Core.Components.select.install();
Core.Components.select.transform("BODY");

