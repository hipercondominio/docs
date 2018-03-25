/// <reference path="Cks.js" />
/// <reference path="Cks.Components.js" />

Cks.Components.Link = {
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
		$("cks-link", selector).each(function () {
			var cp = this;
			if (this.ready)  //já foi transformado
				return;

			///transformação
			$(cp).wrapInner("<a>");

			///propriedades //hack: usar defineProperties
			var _filter;
			var _href;
			var _target;
			Object.defineProperties(cp, {
				filter: {
					get: () => {
						return _filter;
					},
					set: (v) => {
						_filter = v;  //atualizar valor novo
					},
				},
				href: {
					get: () => {
						return $("a", cp).attr("href");
					},
					set: (v) => {
						$("a", cp).attr("href", v);
					},
				},
				target: {
					get: () => {
						return _target;
					},
					set: (v) => {
						var old = _target;
						if (v.startsWith("_") || isFrame(v)) {  //nativo ou iframe
							$("a", cp).off("click");
							$("a", cp).attr("target", v);
						} else {
							$("a", cp).on("click", function () {
								(async function () {
									cp.beforeLoad();
									var data = await Cks.loadSrc(cp.href, cp.target, cp.filter);
									Cks.transformAll(cp.target);
									cp.afterLoad(data);
								})();
								return false;
							});
							$("a", cp).removeAttr("target");
						}
						_target = v;  //atualizar valor novo
					},
				},
			});

			///eventos
			cp.beforeLoad = () => { };
			cp.afterLoad = (data) => { };

			///extrair atributos e setar propriedades
			Cks.attr(cp, "href", String);
			Cks.attr(cp, "target", String, "body");
			Cks.attr(cp, "filter", String);

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