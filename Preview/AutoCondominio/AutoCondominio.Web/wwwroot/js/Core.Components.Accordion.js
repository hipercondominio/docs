/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.Accordion = {
	/**
	 * Faz a configuração inicial do plugin para os componentes do mesmo tipo.
	 * @method
	 * @returns {undefined}
	 * */
	install: () => {

	},

	/**
	 * Efetua o processamento das tags de componente.
	 * @method
	 * @argument selector Seletor css onde ocorrerá a varredura de transformação.
	 * @returns {undefined}
	 * */
	transform: (selector) => {
		var component = this;
		$("cks\\:accordion", selector).each(function() {
			var cksAccordion = this;

			cksAccordion.collapseAll = () => {
				
			}
		});
	}
}

Core.Components.Accordion.install();
Core.Components.Accordion.transform("BODY");

