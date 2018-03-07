/// <reference path="Core.js" />
/// <reference path="Core.Components.js" />

Core.Components.Select = {
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
		$("cks\\:select", selector).each(function() {
			var cksSelect = this;

			$(cksSelect).wrapInner("<select class='form-control'>");
			$(cksSelect).append("<label>");
			var $select = $("select", cksSelect);
			var $label = $("label", cksSelect);

			///definir comportamento das propriedades
			Object.defineProperty(cksSelect, "disabled", {
				get: () => {
					return $select[0].disabled;
				},
				set: (v) => {
					$select[0].disabled = v;
				},
			});

			Object.defineProperty(cksSelect, "multiple", {
				get: () => {
					return $select[0].multiple;
				},
				set: (v) => {
					$select[0].multiple = v;
				},
			});

			Object.defineProperty(cksSelect, "options", {
				get: () => {
					window.setTimeout(() => {
						cksSelect.simplify = cksSelect.simplify;  //somente para disparar o setter que faz a correção visual
					});
					return $select[0].options;
				},
			});

			Object.defineProperty(cksSelect, "required", {
				get: () => {
					return $select[0].required;
				},
				set: (v) => {
					if (v && $select[0].options[0].value != "") {
						var option = new Option("(selecione)", "", true);
						$select.prepend(option);
					}
					$select[0].required = v;
				},
			});

			var _simplify = Symbol("simplify");
			Object.defineProperty(cksSelect, "simplify", {
				get: () => {
					return cksSelect[_simplify];
				},
				set: (v) => {
					if (v && $("option", $select).length == 1) {
						$select.hide();
						$label.html($("option:first", $select).text());
						$label.show();
					} else {
						$label.hide();
						$label.html("");
						$select.show();
					}
					cksSelect[_simplify] = v;
				},
				//todo: e se tiver mais de uma? o usuário adicionar outra option, simplify não deverá ter efeito
			});

			var _helpDisabled = Symbol("helpDisabled");
			Object.defineProperty(cksSelect, "helpDisabled", {
				get: () => {
					return cksSelect[_helpDisabled];
				},
				set: (v) => {
					if (cksSelect.disabled) {
						cksSelect.title = v;
					}
					cksSelect[_helpDisabled] = v;
				},
			});

			Object.defineProperty(cksSelect, "value", {
				get: () => {
					let val = $select.val();
					if (val == "") val = null;
					return val;
				},
				set: (v) => {
					$select.val(v);
				},
			});

			///extrair atributos e setar propriedades
			cksSelect.disabled = cksSelect.getAttribute("disabled") == "" ? true : false;
			cksSelect.multiple = cksSelect.getAttribute("multiple") == "" ? true : false;
			cksSelect.simplify = cksSelect.getAttribute("simplify") == "" ? true : false;
			cksSelect.required = cksSelect.getAttribute("required") == "" ? true : false;
			cksSelect.helpDisabled = cksSelect.getAttribute("help-disabled");
			$select.find("OPTION")[0].selected = true;    //necessário definir antes de saber o que está realmente selecionado
			let attr = cksSelect.getAttribute("value");
			if (attr) {
				cksSelect.value = attr.split(",");
			}


			/*
			$(cksSelect).attr("data-toggle", "tooltip")
				.attr("data-placement", "top")
				.attr("title", cksSelect.getAttribute("help-disabled"));
			$(cksSelect).tooltip();
			//todo: o tooltip estilizado não está funcionando com as recomendações para controle de formulário desabilitado
			*/
		});
	}
}

Core.Components.Select.install();
Core.Components.Select.transform("BODY");

