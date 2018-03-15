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
		var component = this;
		var parent = Core.Components;
		$("cks-pager", selector).each(function () {
			var cks = this;
			if (this.ready)  //já foi transformado
				return;

			var current = `<li class="page-item"><a class="page-link" href="#"><span class="sr-only">0</span></a></li>`

			///transformação
			$(cks).wrapInner(`
				<nav aria-label="Paginador">
					<ul class="pagination">
						<li class="page-item" title="primeira página"><a class="page-link" href="#">&laquo;</a></li>
						<li class="page-item" title="próxima página"><a class="page-link" href="#">&lsaquo;</a></li>
						<li class="page-item active"><a class="page-link">1 <span class="sr-only">página atual</span></a></li>
						<li class="page-item" title="próxima página"><a class="page-link" href="#">&rsaquo;</a></li>
						<li class="page-item" title="última página"><a class="page-link" href="#">&raquo;</a></li>
					</ul>
				</nav>
			`);

			///propriedades
			var _first;
			var _previous;
			var _next;
			var _last;
			Object.defineProperties(cks, {
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

			var _url;

			///eventos
			cks.paging = () => { };

			///extrair atributos e setar propriedades
			cks.first = cks.getAttribute("first") == "" ? true : false;
			cks.previous = cks.getAttribute("previous") == "" ? true : false;
			cks.next = cks.getAttribute("next") == "" ? true : false;
			cks.last = cks.getAttribute("last") == "" ? true : false;

			///funções internas

			this.ready = true;
		});
	}
}
//todo: fazer validação de dados de entrada das propriedades.