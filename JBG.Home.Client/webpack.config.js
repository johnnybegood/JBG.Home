const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin')
const webpackMajorVersion = require('webpack/package.json').version.split('.')[0];

module.exports = {
  context: __dirname,
  entry: './src/index.js',
  output: {
    path: path.join(__dirname, 'dist/webpack-' + webpackMajorVersion),
    publicPath: '',
    filename: 'bundle.js'
  },
  devtool: 'inline-source-map',
  devServer: {
    contentBase: './dist'
  },
  module: {
    rules: [
      {
        test: /\.css$/,
        use: [ 'style-loader', 'css-loader' ]
      },
      {
        test: /index\.mustache$/,
        loader: 'mustache-loader',
        options: {
            tiny: true,
            render: {
                title: 'hello world',
            },
        },
      }
    ]
  },
  plugins: [
    new HtmlWebpackPlugin({
        template: 'src/index.mustache',
        inject: 'body',
    }),
  ]
};