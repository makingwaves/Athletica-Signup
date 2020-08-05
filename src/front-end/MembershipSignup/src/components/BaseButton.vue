<template>
  <div class="baseButton">
    <input type="button" id="in" @click="clicked" :value="text" />
  </div>
</template>

<script>
export default {
  name: "BaseButton",
  props: ["text", "value"],
  methods: {
    clicked() {
      this.$emit("BaseButton-clicked");
    }
  }
};
</script>

<style>
#in {
  background: #47e17a;
  border-radius: 30px;
  border: 0;
  padding: 10px 24px;
}
</style>