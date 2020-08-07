import Vue from 'vue'
import App from './App'
import router from './router'
import { store } from './store/store'
import Vuex from 'vuex'

// Bootstrap-Vue
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import "bootstrap-vue/dist/bootstrap-vue.css"
import BootstrapVue from 'bootstrap-vue'

// Global CSS stylesheet
import './assets/css/global.css'

// HTTP library
import Axios from 'axios'

/* Since we are using Webpack, we can use require.context to 
globally register our very common base components. The code
below is copied from vuejs.org */

import upperFirst from 'lodash/upperFirst'
import camelCase from 'lodash/camelCase'

const requireComponent = require.context(
  // The relative path of the components folder
  './components',
  // Whether or not to look in subfolders
  false,
  // The regular expression used to match base component filenames
  /Base[A-Z]\w+\.(vue|js)$/
)

requireComponent.keys().forEach(fileName => {
  // Get component config
  const componentConfig = requireComponent(fileName)

  // Get PascalCase name of component
  const componentName = upperFirst(
    camelCase(
      // Gets the file name regardless of folder depth
      fileName
        .split('/')
        .pop()
        .replace(/\.\w+$/, '')
    )
  )

  // Register component globally
  Vue.component(
    componentName,
    // Look for the component options on `.default`, which will
    // exist if the component was exported with `export default`,
    // otherwise fall back to module's root.
    componentConfig.default || componentConfig
  )
})

import VueSmoothScroll from 'vue2-smooth-scroll'
 
Vue.use(VueSmoothScroll, {
  duration: 400,
  updateHistory: false,
})

Vue.config.productionTip = false

Axios.defaults.baseURL = process.env.API_ENDPOINT;
process.env.HOST = 'https://athleticasignup.azurewebsites.net'

Vue.use(Vuex)
Vue.use(BootstrapVue)

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  components: { App },
  template: '<App/>'
})
