/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.Collapse = {
	/**
	 * Faz a configuração inicial do plugin para os componentes do mesmo tipo.
	 * @method
	 * @returns {undefined}
	 * */
	install: () => {

	},

	/**
	 * Efetua o processamento das tags de componente.
	 * @method
	 * @argument selector Seletor css onde ocorrerá a varredura de transformação.
	 * @returns {undefined}
	 * */
	transform: (selector) => {
		var component = this;
		var i = 0;  //contador de objetos
		$("cks\\:collapse", selector).each(function() {
			var cksCollapse = this;
			i++;

			///definir comportamento das propriedades
			var _header = Symbol("header");
			Object.defineProperty(cksCollapse, "header", {
				get: () => {
					return cksCollapse[_header];
				},
				set: (v) => {
					$("button", cksCollapse).html(v);
					cksCollapse[_header] = v;
				},
			});

			var _contents = Symbol("contents");
			Object.defineProperty(cksCollapse, "contents", {
				get: () => {
					return cksCollapse[_contents];
				},
				set: (v) => {
					$("div.card-body", cksCollapse).html(v);
					cksCollapse[_contents] = v;
				},
			});

			///extrair atributos e setar propriedades
			cksCollapse.header = cksCollapse.getAttribute("header");
			cksCollapse.contents = cksCollapse.innerHTML;

			///transformação
			var header = cksCollapse.header;
			var contents = cksCollapse.innerHTML;
			cksCollapse.innerHTML = "";
			$(cksCollapse).wrapInner(`
				<div class="card">
					<div class="card-header" id="h${i}">
						<h5 class="mb-0">
							<button class="btn btn-link" data-toggle="collapse" data-target="#c${i}" aria-expanded="true" aria-controls="c${i}">
								<svg viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" class="icon">
									<path d="M0 0h24v24H0z" fill="none" />
									<path d="M13 7h-2v4H7v2h4v4h2v-4h4v-2h-4V7zm-1-5C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 18c-4.41 0-8-3.59-8-8s3.59-8 8-8 8 3.59 8 8-3.59 8-8 8z" />
								</svg>
								<svg viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" class="icon hide">
									<path d="M0 0h24v24H0z" fill="none"/>
									<path d="M7 11v2h10v-2H7zm5-9C6.48 2 2 6.48 2 12s4.48 10 10 10 10-4.48 10-10S17.52 2 12 2zm0 18c-4.41 0-8-3.59-8-8s3.59-8 8-8 8 3.59 8 8-3.59 8-8 8z"/>
								</svg>
								<div>${header}</div>
							</button>
						</h5>
					</div>
					<div id="c${i}" class="collapse show" aria-labelledby="h${i}">
						<div class="card-body">
							${contents}
						</div>
					</div>
				</div>
			`);

			///eventos
			$("div.collapse", cksCollapse).on('show.bs.collapse', function (e) {
				$("button > svg:nth-of-type(1)", cksCollapse).addClass("hide");
				$("button > svg:nth-of-type(2)", cksCollapse).removeClass("hide");
			});
			$("div.collapse", cksCollapse).on('hide.bs.collapse', function (e) {
				$("button > svg:nth-of-type(1)", cksCollapse).removeClass("hide");
				$("button > svg:nth-of-type(2)", cksCollapse).addClass("hide");
			})
		});
	}
}

Core.Components.Collapse.transform("BODY");

