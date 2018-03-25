/// <reference path="Cks.js" />
/// <reference path="Cks.Components.js" />

Cks.Components.NotifyIcon = {
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
		$("cks-notify-icon", selector).each(function () {
			var cp = this;
			if (this.ready)  //já foi transformado
				return;

			///transformação
			$(cp).wrapInner(`
				<a><span class="badge badge-pill badge-primary hide"></span>
					<img />
					<div class="legend"></div></a>
			`);

			///propriedades
			var _url;
			var _size;
			var _width;
			var _height;
			var _target;
			var _filter;
			var _count;
			var _style;
			var _legend;
			Object.defineProperties(cp, {
				href: {
					get: () => {
						return $("a", cp).attr("href");
					},
					set: (v) => {
						$("a", cp).attr("href", v);
					},
				},
				url: {
					get: () => {
						return _url;
					},
					set: (v) => {
						$("img", cp).attr("src", v);
						_url = v;  //atualizar valor novo
					},
				},
				size: {
					get: () => {
						return _size;
					},
					set: (v) => {
						cp.width = v;
						cp.height = v;
						redimImg(v, v);
						_size = v;  //atualizar valor novo
					},
				},
				width: {
					get: () => {
						return _width;
					},
					set: (v) => {
						redimImg(v, cp.height);
						_width = v;  //atualizar valor novo
					},
				},
				height: {
					get: () => {
						return _height;
					},
					set: (v) => {
						redimImg(cp.width, v);
						_height = v;  //atualizar valor novo
					},
				},
				target: {
					get: () => {
						return _target;
					},
					set: (v) => {
						if (v.startsWith("_") || isFrame(v)) {  //nativo ou iframe
							$("a", cp).off("click");
							$("a", cp).attr("target", v);
						} else {
							$("a", cp).on("click", function () {
								(async function () {
									cp.beforeLoad();
									await Cks.loadSrc(cp.href, cp.target, cp.filter);
									Cks.transformAll(cp.target);
									cp.afterLoad();
								})();
								return false;
							});
							$("a", cp).removeAttr("target");
						}
						_target = v;  //atualizar valor novo
					},
				},
				filter: {
					get: () => {
						return _filter;
					},
					set: (v) => {
						_filter = v;  //atualizar valor novo
					},
				},
				count: {
					get: () => {
						return _count;
					},
					set: (v) => {
						var $badge = $(".badge", cp);
						$badge.text(v);
						if (v > 0) {
							$badge.removeClass("hide");
						} else {
							$badge.addClass("hide");
						}
						_count = v;  //atualizar valor novo
					},
				},
				style: {
					get: () => {
						return _style;
					},
					set: (v) => {
						$(".badge", cp)
							.removeClass(`badge-${_style}`)
							.addClass(`badge-${v}`);
						_style = v;  //atualizar valor novo
					},
				},
				legend: {
					get: () => {
						return _legend;
					},
					set: (v) => {
						$("div", cp).text(v);

						_legend = v;  //atualizar valor novo
					},
				},
			});


			///eventos
			cp.beforeLoad = () => { };
			cp.afterLoad = () => { };

			///extrair atributos e setar propriedades
			Cks.attr(cp, "href", String);
			Cks.attr(cp, "target", String, "body");
			Cks.attr(cp, "filter", String);
			Cks.attr(cp, "url", String);
			Cks.attr(cp, "size", String, "24pt");
			Cks.attr(cp, "width", String);
			Cks.attr(cp, "height", String);
			Cks.attr(cp, "count", Number, 0);
			Cks.attr(cp, "style", String, "primary");
			Cks.attr(cp, "legend", String);


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
				$("img", cp).css("width", w).css("height", h);
			}

			this.ready = true;
		});
	}
}
//todo: como mapear o erro de http 404 por exemplo
//todo: herança de Link para esse controle