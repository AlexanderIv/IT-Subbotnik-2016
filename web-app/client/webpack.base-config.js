var ExtractTextPlugin = require('extract-text-webpack-plugin');
var path = require('path');

console.log('Webpack folder: ' + __dirname);

module.exports = {
    resolve: {
        extensions: ['', '.ts', '.js']
    },
    output: {
        filename: '[name].js',
        chunkFilename: '[id].chunk.js',
        path: path.join(__dirname, '../wwwroot'),
        publicPath: '/'
    },
    devtool: 'source-map',
    module: {
        loaders: [{
            test: /\.ts$/,
            exclude: /node_modules\//,
            loaders: ['ts', 'angular2-template'] 
        }, {
            test: /\.html$/,
            loader: 'html'
        }, {
            test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)(\?|$)/,
            loader: 'file?name=assets/[name].[ext]'
        }, {
            test: /\.css$/,
            exclude: /\.component\.css$/,
            loader: ExtractTextPlugin.extract('style', 'css?sourceMap')
        }, {
            test: /\.css$/,
            include: /\.component\.css$/,
            loader: 'raw'
        }]
    },
    plugins: [
        new ExtractTextPlugin('[name].css')
    ]
};