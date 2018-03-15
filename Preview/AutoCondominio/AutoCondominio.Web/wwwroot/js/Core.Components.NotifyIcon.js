/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.NotifyIcon = {
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
		$("cks-notify-icon", selector).each(function () {
			var cks = this;
			if (this.ready)  //já foi transformado
				return;

			///transformação
			$(cks).wrapInner(`
				<a><span class="badge badge-pill badge-primary hide"></span>
					<img />
					<div class="legend"></div></a>
			`);

			///propriedades
			Object.defineProperty(cks, "href", {
				get: () => {
					return $("a", cks).attr("href");
				},
				set: (v) => {
					$("a", cks).attr("href", v);
				},
			});

			var _url;
			Object.defineProperty(cks, "url", {
				get: () => {
					return _url;
				},
				set: (v) => {
					$("img", cks).attr("src", v);
					_url = v;  //atualizar valor novo
				},
			});

			var _size;
			Object.defineProperty(cks, "size", {
				get: () => {
					return _size;
				},
				set: (v) => {
					cks.width = v;
					cks.height = v;
					redimImg(v, v);
					_size = v;  //atualizar valor novo
				},
			});

			var _width;
			Object.defineProperty(cks, "width", {
				get: () => {
					return _width;
				},
				set: (v) => {
					redimImg(v, cks.height);
					_width = v;  //atualizar valor novo
				},
			});

			var _height;
			Object.defineProperty(cks, "height", {
				get: () => {
					return _height;
				},
				set: (v) => {
					redimImg(cks.width, v);
					_height = v;  //atualizar valor novo
				},
			});

			var _target;
			Object.defineProperty(cks, "target", {
				get: () => {
					return _target;
				},
				set: (v) => {
					if (v.startsWith("_") || isFrame(v)) {  //nativo ou iframe
						$("a", cks).off("click");
						$("a", cks).attr("target", v);
					} else {
						$("a", cks).on("click", function () {
							(async function () {
								cks.beforeLoad();
								await parent.loadSrc(cks.href, cks.target, cks.filter);
								parent.transformAll(cks.target);
								cks.afterLoad();
							})();
							return false;
						});
						$("a", cks).removeAttr("target");
					}
					_target = v;  //atualizar valor novo
				},
			});

			var _filter;
			Object.defineProperty(cks, "filter", {
				get: () => {
					return _filter;
				},
				set: (v) => {
					_filter = v;  //atualizar valor novo
				},
			});

			var _count = 0;
			Object.defineProperty(cks, "count", {
				get: () => {
					return _count;
				},
				set: (v) => {
					var $badge = $(".badge", cks);
					$badge.text(v);
					if (v > 0) {
						$badge.removeClass("hide");
					} else {
						$badge.addClass("hide");
					}
					_count = v;  //atualizar valor novo
				},
			});

			var _style = "primary";
			Object.defineProperty(cks, "style", {
				get: () => {
					return _style;
				},
				set: (v) => {
					$(".badge", cks)
						.removeClass(`badge-${_style}`)
						.addClass(`badge-${v}`);
					_style = v;  //atualizar valor novo
				},
			});

			var _legend;
			Object.defineProperty(cks, "legend", {
				get: () => {
					return _legend;
				},
				set: (v) => {
					$("div", cks).text(v);

					_legend = v;  //atualizar valor novo
				},
			});


			///eventos
			cks.beforeLoad = () => { };
			cks.afterLoad = () => { };

			///extrair atributos e setar propriedades
			cks.href = cks.getAttribute("href");
			cks.target = cks.getAttribute("target") || "body";
			cks.filter = cks.getAttribute("filter");
			cks.url = cks.getAttribute("url");
			cks.size = cks.getAttribute("size") || "24pt";
			cks.width = cks.getAttribute("width");
			cks.height = cks.getAttribute("height");
			cks.count = cks.getAttribute("count") || 0;
			cks.style = cks.getAttribute("style") || "primary";
			cks.legend = cks.getAttribute("legend");

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
			 * Redimensiona a imagem de notificação com as medidas fornecidas.
			 * @param {any} w  Width, largura da imagem.
			 * @param {any} h  Height, altura da imagem.
			 * @returns {never}
			 */
			function redimImg(w, h) {
				$("img", cks).css("width", w).css("height", h);
			}

			this.ready = true;
		});
	}
}
//todo: como mapear o erro de http 404 por exemplo
//todo: herança de Link para esse controle