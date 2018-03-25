
/// <reference path="Cks.js" />
/// <reference path="Cks.Components.js" />

Cks.Components.Text = {
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
		$("cks-text", selector).each(function () {
			var cp = this;
			var $cks = $(cp);
			if (cp.ready)  //já foi transformado
				return;

			///transformação
			$cks.wrapInner(`<input type="text" class="form-control" />`);

			var $target = $("INPUT", cp);
			var target = $target[0];

			///propriedades
			var _align;
			var _chars;
			var _helpDisabled;
			var _mask;
			var _tabindex;
			var _name;
			var _required;
			Object.defineProperties(cp, {
				align: {
					get: () => {
						return _align;
					},
					set: (v) => {
						_align = v;
						$target.css("text-align", v);
					},
				},
				autocomplete: {
					get: () => {
						return target.autocomplete;
					},
					set: (v) => {
						target.autocomplete = v;
					},
				},
				chars: {
					get: () => {
						return _chars;
					},
					set: (v) => {
						_chars = v;
					},
				},
				disabled: {
					get: () => {
						return target.disabled;
					},
					set: (v) => {
						target.disabled = v;
					},
				},
				helpDisabled: {
					get: () => {
						return _helpDisabled;
					},
					set: (v) => {
						_helpDisabled = v;
						if (cp.disabled) {
							cp.title = v;
						}
					},
				},
				list: {
					get: () => {
						return target.list;
					},
					set: (v) => {
						target.list = v;
					},
				},
				mask: {
					get: () => {
						return _mask;
					},
					set: (v) => {
						_mask = v;
						Inputmask(cp.mask).mask(target);
					},
				},
				maxlength: {
					get: () => {
						return target.maxlength;
					},
					set: (v) => {
						target.maxlength = v;
					},
				},
				name: {
					get: () => {
						return _name;
					},
					set: (v) => {
						_name = v;
					},
				},
				pattern: {
					get: () => {
						return target.pattern;
					},
					set: (v) => {
						target.pattern = v;
					},
				},
				placeholder: {
					get: () => {
						return target.placeholder;
					},
					set: (v) => {
						target.placeholder = v;
					},
				},
				readonly: {
					get: () => {
						return target.readOnly;
					},
					set: (v) => {
						target.readOnly = v;
					},
				},
				required: {
					get: () => {
						return _required;
					},
					set: (v) => {
						_required = v;
					},
				},
				tabIndex: {
					get: () => {
						return $target.attr("tabindex");
					},
					set: (v) => {
						$target.attr("tabindex", v);
					},
				},
				value: {
					get: () => {
						return target.value;
					},
					set: (v) => {
						target.value = v;
					},
				},
			});

			///extrair atributos e setar propriedades
			Cks.attr(cp, "align", String, "left");
			Cks.attr(cp, "autocomplete", String, false);
			Cks.attr(cp, "chars", String);
			Cks.attr(cp, "disabled", Boolean, false);
			Cks.attr(cp, "help-disabled", String);
			Cks.attr(cp, "list", String);
			Cks.attr(cp, "mask", String);
			Cks.attr(cp, "maxlength", String);
			Cks.attr(cp, "name", String);
			Cks.attr(cp, "pattern", String);
			Cks.attr(cp, "placeholder", String);
			Cks.attr(cp, "readonly", Boolean, false);
			Cks.attr(cp, "required", String, false);
			Cks.attr(cp, "cks:tabindex", Number);
			Cks.attr(cp, "value", String);

			///métodos
			cp.focus = () => {
				$target.focus();
			}
			cp.blur = () => {
				$target.blur();
			}

			///eventos
			Cks.event(target, "focus", cp);
			Cks.event(target, "blur", cp);

			//eventos internos
			$cks.on("keypress", function (e) {
				var k = String.fromCharCode(e.which);
				var charList = e.target.parentNode.chars;
				var reValid = new RegExp(`[${charList}]`);
				if (!reValid.test(k)) {
					return false;
				}
			});

			this.ready = true;
		});
	},
}
