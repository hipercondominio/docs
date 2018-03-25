Cks.Extensions.String = {
	apply: () => {
		/**
		 * Converte uma cadeia no formato kebab-case para camelCase.
		 */
		String.prototype.toCamelCase = function () {
			return this.replace(/[-_]([a-z])/g, function (g) { return g[1].toUpperCase(); })
		};
	},
}
