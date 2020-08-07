<template>
  <div class="baseButton">
    <input type="button" :class="classType" @click="clicked" :value="text" />
  </div>
</template>

<script>
export default {
  name: "BaseButton",
  props: ["text", "value", "classType"],
  methods: {
    clicked() {
      this.$emit("BaseButton-clicked");
    }
  },
  computed: {
    buttonStyle() {
      return this.classType || 'prim';
    }
  }
};
</script>

<style>

</style>