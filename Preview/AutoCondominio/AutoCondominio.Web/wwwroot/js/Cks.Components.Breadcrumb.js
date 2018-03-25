/// <reference path="Cks.js" />
/// <reference path="Cks.Components.js" />

Cks.Components.Breadcrumb = {
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
		$("cks-breadcrumb", selector).each(function () {
			var cp = this;
			if (this.ready)  //já foi transformado
				return;

			///transformação
			var $span = $(cp).append('<span>');
			for (let el of cp.childNodes) {
				if (el.nodeType == 3)  //texto
					el.remove();
			}


			///propriedades
			var _active;
			var _delimiter;

			Object.defineProperties(cp, {
				active: {
					get: () => {
						return _active;
					},
					set: (v) => {
						cp.lastChild.innerHTML = v;
						_active = v;  //atualizar valor novo
					},
				},
				delimiter: {
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
				},
			});

			///extrair atributos e setar propriedades
			Cks.attr(cp, "delimiter", String, "/");
			Cks.attr(cp, "active", String, true);


			this.ready = true;
		});
	}
}
