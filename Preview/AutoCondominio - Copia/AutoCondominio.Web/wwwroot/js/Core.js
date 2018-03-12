var Core = {};

String.prototype.toCamelCase = function () {
	return this.replace(/[-_]([a-z])/g, function (g) { return g[1].toUpperCase(); })
};
