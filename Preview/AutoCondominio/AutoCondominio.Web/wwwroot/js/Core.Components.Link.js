/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.Link = {
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
		var parent = Core.Components;
		$("cks-link", selector).each(function () {
			var cksLink = this;
			if (this.ready)  //já foi transformado
				return;

			///transformação
			var a = document.createElement("a");
			$(cksLink).wrapInner(a);

			///propriedades
			Object.defineProperty(cksLink, "href", {
				get: () => {
					return $("a", cksLink).attr("href");
				},
				set: (v) => {
					$("a", cksLink).attr("href", v);
				},
			});

			var _target;
			Object.defineProperty(cksLink, "target", {
				get: () => {
					return _target;
				},
				set: (v) => {
					var old = _target;
					if (v.startsWith("_") || isFrame(v)) {  //nativo ou iframe
						$("a", cksLink).off("click");
						$("a", cksLink).attr("target", v);
					} else {
						$("a", cksLink).on("click", function () {
							(async function () {
								cksLink.beforeLoad();
								await parent.loadSrc(cksLink.href, cksLink.target, cksLink.filter);
								parent.transformAll(cksLink.target);
								cksLink.afterLoad();
							})();
							return false;
						});
						$("a", cksLink).removeAttr("target");
					}
					_target = v;  //atualizar valor novo
				},
			});

			var _filter;
			Object.defineProperty(cksLink, "filter", {
				get: () => {
					return _filter;
				},
				set: (v) => {
					_filter = v;  //atualizar valor novo
				},
			});

			///eventos
			cksLink.beforeLoad = () => { };
			cksLink.afterLoad = () => { };

			///extrair atributos e setar propriedades
			cksLink.href = cksLink.getAttribute("href");
			cksLink.target = cksLink.getAttribute("target") || "body";
			cksLink.filter = cksLink.getAttribute("filter");

			///funções internas
			/**
			 * Verifica se há dentro da página um frame com nome desejado.
			 * @param {string} name Nome do frame.
			 * @returns {boolean} Verdadeiro se encontrar.
			 * */
			function isFrame(name) {
				return document.querySelector(`IFRAME[name='${name}']`) != null;
			}

			this.ready = true;
		});
	}
}
//todo: como mapear o erro de http 404 por exemplo