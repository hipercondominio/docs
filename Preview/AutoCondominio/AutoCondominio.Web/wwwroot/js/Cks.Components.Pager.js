/// <reference path="Cks.js" />
/// <reference path="Cks.Components.js" />

Cks.Components.Pager = {
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
		$("cks-pager", selector).each(function () {
			var cp = this;
			if (this.ready)  //já foi transformado
				return;

			///transformação
			$(cp).wrapInner(`
				<nav aria-label="Paginador">
					<ul class="pagination">
						<li class="page-item fix" title="primeira página"><a class="page-link first">&laquo;</a></li>
						<li class="page-item fix" title="página anterior"><a class="page-link previous">&lsaquo;</a></li>
						<li class="page-item fix" title="próxima página"><a class="page-link next">&rsaquo;</a></li>
						<li class="page-item fix" title="última página"><a class="page-link last">&raquo;</a></li>
					</ul>
				</nav>
			`);
			var $tpln = $(`<li class="page-item normal"><a class="page-link">1</a></li>`);  //template de página
			var $tpla = $(`<li class="page-item active"><a class="page-link">1</a><span class="sr-only">página atual</span></li>`);  //template de página ativa


			///propriedades
			var _first;  //botão primeiro
			var _previous;  //botão anterior
			var _next;  //botão próximo
			var _last;  //botão último
			var _records;  //total de registros
			var _recordsPage;  //total de registros por página
			var _page;  //página atual
			var _pageShow;  //número de páginas a serem exibidas no pager
			Object.defineProperties(cp, {
				pages: {
					get: () => {
						return Math.ceil(cp.records / cp.recordsPage);
					},
				},
				pageShow: {
					get: () => {
						return _pageShow;
					},
					set: (v) => {
						_pageShow = v;
						window.setTimeout(() => {
							recalc();
						});
					},
				},
				page: {
					get: () => {
						return _page;
					},
					set: (v) => {
						_page = Math.limit(v, 1, cp.pages);
						window.setTimeout(() => {
							refresh();
						});
					},
				},
				recordsPage: {
					get: () => {
						return _recordsPage;
					},
					set: (v) => {
						_recordsPage = v;
						window.setTimeout(() => {
							recalc();
						});
					},
				},
				records: {
					get: () => {
						return _records;
					},
					set: (v) => {
						_records = v;
						window.setTimeout(() => {
							recalc();
						});
					},
				},
				first: {
					get: () => {
						return _first;
					},
					set: (v) => {
						var $li = $("li:first", cp);
						if (v) {
							$li.removeClass("hide");
						} else {
							$li.addClass("hide");
						}
						_first = v;
					},
				},
				previous: {
					get: () => {
						return _previous;
					},
					set: (v) => {
						var $li = $("li:nth-of-type(2)", cp);
						if (v) {
							$li.removeClass("hide");
						} else {
							$li.addClass("hide");
						}
						_previous = v;
					},
				},
				next: {
					get: () => {
						return _next;
					},
					set: (v) => {
						var $li = $("li:nth-last-of-type(2)", cp);
						if (v) {
							$li.removeClass("hide");
						} else {
							$li.addClass("hide");
						}
						_next = v;
					},
				},
				last: {
					get: () => {
						return _last;
					},
					set: (v) => {
						var $li = $("li:nth-last-of-type(1)", cp);
						if (v) {
							$li.removeClass("hide");
						} else {
							$li.addClass("hide");
						}
						_last = v;
					},
				},
			});

			///extrair atributos e setar propriedades
			Cks.attr(cp, "first", Boolean, true);
			Cks.attr(cp, "previous", Boolean, true);
			Cks.attr(cp, "next", Boolean, true);
			Cks.attr(cp, "last", Boolean, true);
			Cks.attr(cp, "first", Boolean, true);
			Cks.attr(cp, "records", Number, 0);
			Cks.attr(cp, "records-page", Number, 0);
			Cks.attr(cp, "page", Number, 1);
			Cks.attr(cp, "page-show", Number, 3);

			///eventos
			/**
			 * Ocorre quando muda a página atual.
			 * @param {number} old  Página anterior.
			 * @param {number} active  Página atual.
			 * @returns {never}
			 */
			cp.paging = new Function("page", cp.getAttribute("onpaging"));

			///funções internas
			/**
			 * Faz a criação das páginas disponíveis para seleção.
			 * @returns {never}
			 */
			function recalc() {
				//verificar se a quantidade de páginas desejadas está disponível para mostrar
				var show = cp.pageShow;
				if (show > cp.pages)
					show = cp.pages;

				var showed = $("li:not(.fix)", cp).length;  //verificar o número de páginas exibidas
				if (showed == show)
					return;  //nada mudou

				var midPoint = show / 2;
				if (midPoint != Math.trunc(midPoint)) {  //se for número racional, arredondar pra cima
					midPoint = Math.ceil(midPoint);
				}

				//preencher
				$("li:not(.fix)", cp).remove();
				for (let i = 1; i <= show; i++) {
					$("li:nth-last-of-type(2)", cp).before($tpln.clone());
				}

				refresh();
			}

			/**
			 * Faz a atualização das páginas visíveis no pager.
			 * @returns {never}
			 */
			function refresh() {
				//verificar se a quantidade de páginas desejadas está disponível para mostrar
				var show = cp.pageShow;
				if (show > cp.pages)
					show = cp.pages;

				//ajustar o ponto médio da página ativa
				var midPoint = show / 2;
				if (midPoint != Math.trunc(midPoint)) {  //se for número racional, arredondar pra baixo
					midPoint = Math.floor(midPoint);
				} else {
					midPoint--;
				}

				//ajustar páginas limite mínimo e máximo
				var start = Math.limit(cp.page - midPoint, 1, cp.pages - cp.pageShow + 1);
				var end = start + show - 1;

				//remover antigo template de active
				$("li.active", cp).replaceWith($tpln.clone());

				//numerar
				var p = 0;  //indexador de elementos página 'li'
				for (let i = start; i <= end; i++) {  //percorrer número inicial e final, numerando
					let li = $("li:not(.fix)", cp)[p];
					if (i == cp.page) {  //chegou na página ativa, mudar template
						$(li).replaceWith($tpla.clone());
						li = $("li:not(.fix)", cp)[p];  //recuperar item pois foi desvinculado
					}
					$("a", li).text(i);
					p++;
				}
				$("li", cp).off("click");
				$("li", cp).on("click", pageClick);
			}

			/**
			 * Ocorre quando o usuário clica em outra página.
			 * */
			function pageClick(e) {
				var $link = $(e.target);
				if ($link.hasClass("first")) {
					cp.page = 1;
				} else if ($link.hasClass("previous")) {
					--cp.page;
				} else if ($link.hasClass("next")) {
					++cp.page;
				} else if ($link.hasClass("last")) {
					cp.page = cp.pages;
				} else {
					cp.page = parseInt(e.target.innerText);
				}
				cp.paging(cp.page);
			}


			this.ready = true;
		});
	}
}
//todo: fazer validação de dados de entrada das propriedades.
//todo: revisar comentários que faltaram nos arquivos anteriores, como funções internas e eventos.