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
		$("cks\\:link", selector).each(function () {
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

			var _target = Symbol("target");
			Object.defineProperty(cksLink, "target", {
				get: () => {
					return cksLink[_target];
				},
				set: (v) => {
					var old = cksLink[_target];
					if (v.startsWith("_") || isFrame(v)) {  //nativo ou iframe
						$("a").off("click");
						$("a", cksLink).attr("target", v);
					} else {
						$("a").on("click", function () {
							cksLink.beforeLoad();
							load(cksLink.href, cksLink.target, cksLink.filter);
							cksLink.afterLoad();
							return false;
						});
						$("a", cksLink).removeAttr("target");
					}
					cksLink[_target] = v;  //atualizar valor novo
				},
			});

			var _filter = Symbol("filter");
			Object.defineProperty(cksLink, "filter", {
				get: () => {
					return cksLink[_filter];
				},
				set: (v) => {
					cksLink[_filter] = v;  //atualizar valor novo
				},
			});

			///eventos
			cksLink.beforeLoad = () => { };
			cksLink.afterLoad = () => { };

			///extrair atributos e setar propriedades
			cksLink.href = cksLink.getAttribute("href");
			cksLink.target = cksLink.getAttribute("target");
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

			/**
			 * Insere um conteúdo externo dentro de um alvo de link.
			 * @param {string} href Url de origem dos dados.
			 * @param {string} target Seletor de destino dos dados obtidos.
			 * @param {string} filter Seletor que delimita a porção dos dados que será inserida.
			 * @returns {never}
			 * */
			async function load(href, target, filter) {
				var contents = await jQuery.get(href);
				if (filter)
					contents = $(filter, $(contents));
				$(target).html(contents);

				Core.Components.transformAll(target);
			}

			this.ready = true;
		});
	}
}
