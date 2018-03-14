/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.Collapse = {
	/**
	 * Faz a configuração inicial do plugin para os componentes do mesmo tipo.
	 * @returns {never}
	 * */
	install: () => {
		Core.Components.Collapse.counter = 0;  //contador global para não repetir ids
	},

	/**
	 * Efetua o processamento das tags de componente.
	 * @param selector Seletor css onde ocorrerá a varredura de transformação.
	 * @returns {never}
	 * */
	transform: (selector) => {
		var component = this;
		
		$("cks\\:collapse", selector).each(function () {
			var cksCollapse = this;
			if (this.ready)  //já foi transformado
				return;
			var i = Core.Components.Collapse.counter++;

			///propriedades
			var _header;
			Object.defineProperty(cksCollapse, "header", {
				get: () => {
					return _header;
				},
				set: (v) => {
					$(".card-header .htext:first", cksCollapse).html(v);
					_header = v;
				},
			});

			var _contents;
			Object.defineProperty(cksCollapse, "contents", {
				get: () => {
					return _contents;
				},
				set: (v) => {
					$(".card-body:first", cksCollapse).html(v);
					_contents = v;
				},
			});

			var _state = 'close';  //default
			Object.defineProperty(cksCollapse, "state", {
				get: () => {
					return _state;
				},
				set: (v) => {
					if (v == 'open') {
						switchIcon(v);
						$(".collapse:first", cksCollapse).collapse('show')
					} else if (v == 'close') {
						switchIcon(v);
						$(".collapse:first", cksCollapse).collapse('hide');
					}
					_state = v;
				},
			});

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
								<div class="ml-1 htext">${header}</div>
							</button>
						</h5>
					</div>
					<div id="c${i}" class="collapse" aria-labelledby="h${i}">
						<div class="card-body">
							${contents}
						</div>
					</div>
				</div>
			`);

			///extrair atributos e setar propriedades
			cksCollapse.header = cksCollapse.getAttribute("header");
			cksCollapse.state = cksCollapse.getAttribute("state");

			///eventos
			$("> div > div:nth-of-type(2)", cksCollapse).on('show.bs.collapse', function (e) {
				switchIcon('open');
				_state = 'open';
			});
			$("> div > div:nth-of-type(2)", cksCollapse).on('hide.bs.collapse', function (e) {
				switchIcon('close');
				_state = 'close';
			});

			///funções internas
			/**
			 * Faz a manipulação do ícone de estado do collapse.
			 * @param {string} state  Estado do collapse ('open'|'close').
			 * */
			function switchIcon(state) {
				if (state == 'open') {
					$(".icon:nth-of-type(1)", cksCollapse).addClass("hide");
					$(".icon:nth-of-type(2)", cksCollapse).removeClass("hide");
				} else {
					$(".icon:nth-of-type(1)", cksCollapse).removeClass("hide");
					$(".icon:nth-of-type(2)", cksCollapse).addClass("hide");
				}
			}

			this.ready = true;
		});
	}
}
