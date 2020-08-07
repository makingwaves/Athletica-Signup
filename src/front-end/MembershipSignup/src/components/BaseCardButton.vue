<template>
    <div class="cardButton">
        <slot name="cardbtn"></slot>
        <input type="button" @click="clicked"/>
    </div>
</template>

<script>
export default {
    name: "BaseCardButton",
    methods: {
    clicked() {
      this.$emit("BaseCardButton-clicked");
    }
  }
}
</script>

<style>

</style>