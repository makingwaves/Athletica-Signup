<template>
  <div class="baseInfoBox" :style="{'background-color': color}">
    <p>{{ label }}</p>
  </div>
</template>

<script>
export default {
  name: "BaseInfoBox",
  props: {
    label: String,
    color: String
  },
  components: {}
};
</script>

<style>
.baseInfoBox {
  display: inline-block;
  padding: 12px 12px 4px 12px;
  border-radius: 7px;
  font-size: 12px;
}
</style>