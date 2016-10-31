var webpackConfig = require('./webpack.base-config');

var nodeExternals = require('webpack-node-externals');
var webpackMerge = require('webpack-merge');

var allFilenamesExceptJavaScript = /\.(?!js(\?|$))([^.]+(\?|$))/;

var x = webpackMerge(webpackConfig, {
    entry: {
        app: './src/boot-server.ts'
    },
    target: 'node',
    devtool: 'inline-source-map',
    node: {
        console: true
    },
    externals: [nodeExternals({ whitelist: [allFilenamesExceptJavaScript] })] // Don't bundle .js files from node_modules
});
console.log('SERVER WEBPACK CONFIG = ' + JSON.stringify(x));
module.exports = x;