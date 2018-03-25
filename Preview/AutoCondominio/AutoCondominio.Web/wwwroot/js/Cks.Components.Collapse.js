/// <reference path="Cks.js" />
/// <reference path="Cks.Components.js" />

Cks.Components.Collapse = {
	/**
	 * Faz a configuração inicial do plugin para os componentes do mesmo tipo.
	 * @returns {never}
	 * */
	install: () => {
		Cks.Components.Collapse.counter = 0;  //contador global para não repetir ids
	},

	/**
	 * Efetua o processamento das tags de componente.
	 * @param selector Seletor css onde ocorrerá a varredura de transformação.
	 * @returns {never}
	 * */
	transform: (selector) => {
		$("cks-collapse", selector).each(function () {
			var cp = this;
			if (this.ready)  //já foi transformado
				return;
			var i = Cks.Components.Collapse.counter++;

			///propriedades
			var _contents;
			var _header;
			var _state;
			Object.defineProperties(cp, {
				contents: {
					get: () => {
						return _contents;
					},
					set: (v) => {
						$(".card-body:first", cp).html(v);
						_contents = v;
					},
				},
				header: {
					get: () => {
						return _header;
					},
					set: (v) => {
						$(".card-header .htext:first", cp).html(v);
						_header = v;
					},
				},
				state: {
					get: () => {
						return _state;
					},
					set: (v) => {
						if (v == 'open') {
							switchIcon(v);
							$(".collapse:first", cp).collapse('show')
						} else if (v == 'close') {
							switchIcon(v);
							$(".collapse:first", cp).collapse('hide');
						}
						_state = v;
					},
				},
			});

			///transformação
			var header = cp.header;
			var contents = cp.innerHTML;
			cp.innerHTML = "";
			$(cp).wrapInner(`
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
			Cks.attr(cp, "header", String);
			Cks.attr(cp, "state", String, "close");

			///eventos manipulados
			$("> div > div:nth-of-type(2)", cp).on('show.bs.collapse', function (e) {
				switchIcon('open');
				_state = 'open';
			});
			$("> div > div:nth-of-type(2)", cp).on('hide.bs.collapse', function (e) {
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
					$(".icon:nth-of-type(1)", cp).addClass("hide");
					$(".icon:nth-of-type(2)", cp).removeClass("hide");
				} else {
					$(".icon:nth-of-type(1)", cp).removeClass("hide");
					$(".icon:nth-of-type(2)", cp).addClass("hide");
				}
			}

			this.ready = true;
		});
	}
}
