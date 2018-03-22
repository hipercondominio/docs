/**
 * Converte uma cadeia no formato kebab-case para camelCase.
 */
String.prototype.toCamelCase = function () {
	return this.replace(/[-_]([a-z])/g, function (g) { return g[1].toUpperCase(); })
};

/**
 * Determina os limites permitidos para um valor. Se for menor que 'min', iguala a 'min'; se maior que 'max', iguala a 'max'.
 * @param {number} val  Valor a ser analisado.
 * @param {number} min  Valor m�nimo permitido.
 * @param {number} max  Valor m�ximo permitido.
 */
Math.limit = function (val, min, max) {
	if (val < min) {
		return min;
	} else if (val > max) {
		val = max;
		return max;
	} else {
		return val;
	}
}


var Core = {};

