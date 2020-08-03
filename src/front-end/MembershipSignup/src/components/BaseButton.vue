<template>

    <div id="BaseButton">
        <input type="button" id="in" @click="clicked" :value="text"/>
    </div>

</template>

<script>

export default {
    name: 'BaseButton',
    props: [
        'text',
        'value'
    ],
    methods: {
        clicked() {
            this.$emit('BaseButton-clicked')
        }
    }
}
</script>

<style>

</style>