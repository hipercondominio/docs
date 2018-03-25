/// <reference path="Cks.js" />
/// <reference path="Cks.Components.js" />

Cks.Components.Select = {
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
		$("cks-select", selector).each(function () {
			var cp = this;
			if (this.ready)  //já foi transformado
				return;

			$(cp).wrapInner("<select class='form-control'>");
			$(cp).append("<label>");
			var $select = $("select", cp);
			var $label = $("label", cp);

			///propriedades
			var _required;
			var _simplify;
			var _helpDisabled;
			Object.defineProperties(cp, {
				disabled: {
					get: () => {
						return $select[0].disabled;
					},
					set: (v) => {
						$select[0].disabled = v;
					},
				},
				length: {
					get: () => {
						return $select[0].length;
					},
				},
				multiple: {
					get: () => {
						return $select[0].multiple;
					},
					set: (v) => {
						$select[0].multiple = v;
					},
				},
				options: {
					get: () => {
						window.setTimeout(() => {
							cp.simplify = cp.simplify;  //somente para disparar o setter que faz a correção visual
						});
						return $select[0].options;
					},
				},
				required: {
					get: () => {
						return _required;
					},
					set: (v) => {
						_required = v;
						if (v == true && $select[0].options[0].value != "") {
							var option = new Option("(selecione)", "", true);
							$select.prepend(option);
						} else if (v == false && $select[0].options[0].value == "") {
							$select.find("option:first").remove();
						}
					},
				},
				selectedindex: {
					get: () => {
						return $select[0].selectedIndex;
					},
					set: (v) => {
						$select[0].selectedIndex = v;
					},
				},
				simplify: {
					get: () => {
						return _simplify;
					},
					set: (v) => {
						if (v == true && $("option", $select).length == 1) {
							$select.hide();
							$label.html($("option:first", $select).text());
							$label.show();
						} else {
							$label.hide();
							$label.html("");
							$select.show();
						}
						_simplify = v;
					},
				},
				helpDisabled: {
					get: () => {
						return _helpDisabled;
					},
					set: (v) => {
						if (cp.disabled) {
							cp.title = v;
						}
						_helpDisabled = v;
					},
				},
				value: {
					get: () => {
						let val = $select.val();
						if (val == "") val = null;
						return val;
					},
					set: (v) => {
						$select.val(v);
					},
				},
			});

			///extrair atributos e setar propriedades
			Cks.attr(cp, "disabled", Boolean, false);
			Cks.attr(cp, "multiple", Boolean, false);
			Cks.attr(cp, "simplify", Boolean, true);
			Cks.attr(cp, "required", Boolean, false);
			Cks.attr(cp, "help-disabled", Boolean, false);

			$select.find("OPTION")[0].selected = true;    //necessário definir antes de saber o que está realmente selecionado
			if (cp.multiple)
				Cks.attr(cp, "value", Array);
			else
				Cks.attr(cp, "value", String);


			/*
			$(cksSelect).attr("data-toggle", "tooltip")
				.attr("data-placement", "top")
				.attr("title", cksSelect.getAttribute("help-disabled"));
			$(cksSelect).tooltip();
			//todo: o tooltip estilizado não está funcionando com as recomendações para controle de formulário desabilitado
			*/

			this.ready = true;
		});
	}
}
