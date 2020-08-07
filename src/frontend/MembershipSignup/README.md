# Membership Sign-up System for SiO Athletica

## Build Setup

``` bash
# install dependencies
npm install

# serve with hot reload at localhost:8080
npm run dev

# build for production with minification
npm run build

# build for production and view the bundle analyzer report
npm run build --report

# run unit tests
npm run unit

# run all tests
npm test
```

## Implementation details

The web application is built using Vue.js with Webpack. The structure is as follows:
// Put figure here
Validation in frontend is used mostly to accommodate usability, while backend makes sure that the data definitely is valid.

### API

API folder with files for related api calls, divided into the tables in the database
httpClient creates an axios client, the {table}.api.js classes use this client to make the calls. the httpFactory uses the repository pattern to make the api easily accessible in the entire application.

### Vuex - state management

We are using Vuex, the standard state management pattern + library for Vue.js applications. All vital variables needed to create a new membership are stored in the Vuex store.

### Components

Base components globally registered in main.js
Add picture of structure parent / child components

### Assets

Inline SVG - created svg-icon component to enable easy use of svg icons
Global css containing new design system for SiO