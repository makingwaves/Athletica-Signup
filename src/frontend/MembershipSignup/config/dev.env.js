'use strict'
const merge = require('webpack-merge')
const prodEnv = require('./prod.env')
const prodEndpoint = process.env.PRODUCTION_ENDPOINT

module.exports = merge(prodEnv, {
  NODE_ENV: '"development"',
  API_ENDPOINT: '"http://localhost:5000/"'
})