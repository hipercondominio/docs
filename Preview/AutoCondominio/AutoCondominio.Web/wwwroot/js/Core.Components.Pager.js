/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.Pager = {
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
		var parent = Core.Components;
		$("cks-pager", selector).each(function () {
			var cks = this;
			if (this.ready)  //já foi transformado
				return;

			///transformação
			$(cks).wrapInner(`
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
			Object.defineProperties(cks, {
				"pages": {
					get: () => {
						return Math.ceil(cks.records / cks.recordsPage);
					},
				},
				"pageShow": {
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
				"page": {
					get: () => {
						return _page;
					},
					set: (v) => {
						_page = Math.limit(v, 1, cks.pages);
						window.setTimeout(() => {
							refresh();
						});
					},
				},
				"recordsPage": {
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
				"records": {
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
				"first": {
					get: () => {
						return _first;
					},
					set: (v) => {
						var $li = $("li:first", cks);
						if (v) {
							$li.removeClass("hide");
						} else {
							$li.addClass("hide");
						}
						_first = v;
					},
				},
				"previous": {
					get: () => {
						return _previous;
					},
					set: (v) => {
						var $li = $("li:nth-of-type(2)", cks);
						if (v) {
							$li.removeClass("hide");
						} else {
							$li.addClass("hide");
						}
						_previous = v;
					},
				},
				"next": {
					get: () => {
						return _next;
					},
					set: (v) => {
						var $li = $("li:nth-last-of-type(2)", cks);
						if (v) {
							$li.removeClass("hide");
						} else {
							$li.addClass("hide");
						}
						_next = v;
					},
				},
				"last": {
					get: () => {
						return _last;
					},
					set: (v) => {
						var $li = $("li:nth-last-of-type(1)", cks);
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
			cks.first = cks.getAttribute("first") == "" ? true : false;
			cks.previous = cks.getAttribute("previous") == "" ? true : false;
			cks.next = cks.getAttribute("next") == "" ? true : false;
			cks.last = cks.getAttribute("last") == "" ? true : false;
			cks.records = parseInt(cks.getAttribute("records")) || 0;
			cks.recordsPage = parseInt(cks.getAttribute("records-page")) || 0;
			cks.page = parseInt(cks.getAttribute("page")) || 1;
			cks.pageShow = parseInt(cks.getAttribute("page-show")) || 3;

			///eventos
			/**
			 * Ocorre quando muda a página atual.
			 * @param {number} old  Página anterior.
			 * @param {number} active  Página atual.
			 * @returns {never}
			 */
			cks.paging = new Function("page", cks.getAttribute("onpaging"));

			///funções internas
			/**
			 * Faz a criação das páginas disponíveis para seleção.
			 * @returns {never}
			 */
			function recalc() {
				//verificar se a quantidade de páginas desejadas está disponível para mostrar
				var show = cks.pageShow;
				if (show > cks.pages)
					show = cks.pages;

				var showed = $("li:not(.fix)", cks).length;  //verificar o número de páginas exibidas
				if (showed == show)
					return;  //nada mudou

				var midPoint = show / 2;
				if (midPoint != Math.trunc(midPoint)) {  //se for número racional, arredondar pra cima
					midPoint = Math.ceil(midPoint);
				}

				//preencher
				$("li:not(.fix)", cks).remove();
				for (let i = 1; i <= show; i++) {
					$("li:nth-last-of-type(2)", cks).before($tpln.clone());
				}

				refresh();
			}

			/**
			 * Faz a atualização das páginas visíveis no pager.
			 * @returns {never}
			 */
			function refresh() {
				//verificar se a quantidade de páginas desejadas está disponível para mostrar
				var show = cks.pageShow;
				if (show > cks.pages)
					show = cks.pages;

				//ajustar o ponto médio da página ativa
				var midPoint = show / 2;
				if (midPoint != Math.trunc(midPoint)) {  //se for número racional, arredondar pra baixo
					midPoint = Math.floor(midPoint);
				} else {
					midPoint--;
				}

				//ajustar páginas limite mínimo e máximo
				var start = Math.limit(cks.page - midPoint, 1, cks.pages - cks.pageShow + 1);
				var end = start + show - 1;

				//remover antigo template de active
				$("li.active", cks).replaceWith($tpln.clone());

				//numerar
				var p = 0;  //indexador de elementos página 'li'
				for (let i = start; i <= end; i++) {  //percorrer número inicial e final, numerando
					let li = $("li:not(.fix)", cks)[p];
					if (i == cks.page) {  //chegou na página ativa, mudar template
						$(li).replaceWith($tpla.clone());
						li = $("li:not(.fix)", cks)[p];  //recuperar item pois foi desvinculado
					}
					$("a", li).text(i);
					p++;
				}
				$("li", cks).off("click");
				$("li", cks).on("click", pageClick);
			}

			/**
			 * Ocorre quando o usuário clica em outra página.
			 * */
			function pageClick(e) {
				var $link = $(e.target);
				if ($link.hasClass("first")) {
					cks.page = 1;
				} else if ($link.hasClass("previous")) {
					--cks.page;
				} else if ($link.hasClass("next")) {
					++cks.page;
				} else if ($link.hasClass("last")) {
					cks.page = cks.pages;
				} else {
					cks.page = parseInt(e.target.innerText);
				}
				cks.paging(cks.page);
			}


			this.ready = true;
		});
	}
}
//todo: fazer validação de dados de entrada das propriedades.
//todo: revisar comentários que faltaram nos arquivos anteriores, como funções internas e eventos.