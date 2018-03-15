/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.Breadcrumb = {
	/**
	 * Faz a configuração inicial do plugin para os componentes do mesmo tipo.
	 * @returns {never}
	 * */
	install: () => {

	},

	/**
	 * Efetua o processamento das tags de componente.
	 * @argument selector Seletor css onde ocorrerá a varredura de transformação.
	 * @returns {never}
	 * */
	transform: (selector) => {
		var component = this;
		$("cks-breadcrumb", selector).each(function () {
			var cks = this;
			if (this.ready)  //já foi transformado
				return;

			///transformação
			var $span = $(cks).append('<span>');
			for (let el of cks.childNodes) {
				if (el.nodeType == 3)  //texto
					el.remove();
			}
			

			///propriedades
			var _active;
			Object.defineProperty(cks, "active", {
				get: () => {
					return _active;
				},
				set: (v) => {
					cks.lastChild.innerHTML = v;
					_active = v;  //atualizar valor novo
				},
			});

			var _delimiter;
			Object.defineProperty(cks, "delimiter", {
				get: () => {
					return _delimiter;
				},
				set: (v) => {
					let content;
					if (v.startsWith("url("))
						content = v;
					else
						content = `'${v}'`;
					$("head").append(`
						<style id="breadcrumb" type="text/css">
							cks-breadcrumb > cks-link:after {
								content: ${content};
							}
						</style>
					`);
					_delimiter = v;  //atualizar valor novo
				},
			});


			///eventos
			//nenhum

			///extrair atributos e setar propriedades
			cks.delimiter = cks.getAttribute("delimiter");
			cks.active = cks.getAttribute("active");

			///funções internas
			//nada

			this.ready = true;
		});
	}
}
