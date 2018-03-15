/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.Accordion = {
	/**
	 * Faz a configuração inicial do plugin para os componentes do mesmo tipo.
	 * @returns {never}
	 * */
	install: () => {

	},

	/**
	 * Efetua o processamento das tags de componente.
	 * @param selector Seletor css onde ocorrerá a varredura de transformação.
	 * @returns {never}
	 * */
	transform: (selector) => {
		var component = this;
		$("cks-accordion", selector).each(function() {
			var cksAccordion = this;
			if (this.ready)  //já foi transformado
				return;

			///propriedades
			var _expandAll = false;  //default
			Object.defineProperty(cksAccordion, "expandAll", {
				get: () => {
					return _expandAll;
				},
				set: (v) => {
					var old = _expandAll;
					if (old == false && v == true) {
						$(".expand-all:first", cksAccordion).removeClass("hide");
					} else if (old == true && v == false) {
						$(".expand-all:first", cksAccordion).addClass("hide");
					}
					_expandAll = v;  //atualizar valor novo
				},
			});

			var _collapseAll = false;  //default
			Object.defineProperty(cksAccordion, "collapseAll", {
				get: () => {
					return _collapseAll;
				},
				set: (v) => {
					var old = _collapseAll;
					if (old == false && v == true) {
						$(".collapse-all:first", cksAccordion).removeClass("hide");
					} else if (old == true && v == false) {
						$(".collapse-all:first", cksAccordion).addClass("hide");
					}
					_collapseAll = v;  //atualizar valor novo
				},
			});

			///transformação
			$(cksAccordion).prepend(`
				<div class="text-right">
					<span title="expandir todos" class="expand-all hide">
						<svg viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" class="icon">
							<path d="M16.21 4.16l4 4v-4zm4 12l-4 4h4zm-12 4l-4-4v4zm-4-12l4-4h-4zm12.95-.95c-2.73-2.73-7.17-2.73-9.9 0s-2.73 7.17 0 9.9 7.17 2.73 9.9 0 2.73-7.16 0-9.9zm-1.1 8.8c-2.13 2.13-5.57 2.13-7.7 0s-2.13-5.57 0-7.7 5.57-2.13 7.7 0 2.13 5.57 0 7.7z" fill="#010101" />
							<path d="M.21.16h24v24h-24z" fill="none" />
						</svg>
					</span>
					<span title="recolher todos" class="collapse-all hide">
						<svg viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" class="icon">
							<path d="M4 15h16v-2H4v2zm0 4h16v-2H4v2zm0-8h16V9H4v2zm0-6v2h16V5H4z" />
							<path d="M0 0h24v24H0V0z" fill="none" />
						</svg>
					</span>
				</div>
			`);

			///extrair atributos e setar propriedades
			cksAccordion.expandAll = cksAccordion.getAttribute("expand-all") == "" ? true : false;
			cksAccordion.collapseAll = cksAccordion.getAttribute("collapse-all") == "" ? true : false;

			///eventos manipulados
			$(".expand-all:first", cksAccordion).on("click", function () {
				$("cks-collapse", cksAccordion).each(function () {
					this.state = 'open';
				});
			});
			$(".collapse-all:first", cksAccordion).on("click", function () {
				$("cks-collapse", cksAccordion).each(function () {
					this.state = 'close';
				});
			});

			this.ready = true;
		});
	}
}
