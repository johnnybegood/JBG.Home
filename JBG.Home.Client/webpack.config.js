const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const HtmlWebpackPlugin = require('html-webpack-plugin');
const webpack = require('webpack');

module.exports = {
  context: __dirname,
  entry: {
    main: './src/index.js'
  },
  output: {
    path: path.join(__dirname, '../JBG.Home.Server/wwwroot'),
    publicPath: '/',
    filename: 'bundle.[hash].js'
  },
  devtool: 'inline-source-map',
  devServer: {
    contentBase: './dist',
    hot: true
  },
  module: {
    rules: [
      {
        test: /\.css$/,
        use: [ { loader: MiniCssExtractPlugin.loader }, 'css-loader' ]
      },
      {
        test: /\.(woff(2)?|ttf|eot)(\?v=\d+\.\d+\.\d+)?$/,
        use: [{
            loader: 'file-loader',
            options: {
                name: '[name].[ext]',
                outputPath: 'fonts/'
            }
        }]
      },
      {
        test: /\.svg$/,
        use: [
          {
            loader: 'file-loader',
            options: {
                name: '[name].[hash].[ext]',
                outputPath: 'icons/'
            }
          }
        ]
      },
      { 
        test: /\.handlebars$/, 
        loader: "handlebars-loader"
      }
    ]
  },
  plugins: [
    new MiniCssExtractPlugin({
      filename: "[name].[hash].css",
      chunkFilename: "[id].[hash].css"
    }),
    new HtmlWebpackPlugin({
        template: 'src/index.html',
        inject: 'body',
    }),
    new webpack.HotModuleReplacementPlugin()
  ]
};