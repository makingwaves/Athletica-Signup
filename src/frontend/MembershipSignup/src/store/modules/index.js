/*
Automatically imports all the modules and exports as single module object


const requireModule = require.context('.', false, /\.module\.js$/);
const modules = {};

require.keys().forEach(filename => {

    // Creates the module name from fileName
    // Remove the module.js extension and capitalize
    const moduleName = filename
                .replace(/(\.\/|\.store\.js)/g, '')
                .replace(/^\w/, c => c.toUpperCase())

    modules[moduleName] = requireModule(filename).default || requireModule(filename);

});

export default modules;
*/