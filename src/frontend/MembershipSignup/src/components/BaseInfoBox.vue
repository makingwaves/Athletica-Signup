<template>
  <div class="baseInfoBox" :style="{ 'background-color': color }">
    <img v-if="!hideIcon" src="../assets/icons/info.svg" />
    <p>{{ label }}</p>
    <slot name="content" />
  </div>
</template>

<script>
export default {
  name: "BaseInfoBox",
  props: {
    label: String,
    color: String,
    hideIcon: Boolean
  },
  components: {}
};
</script>

<style>
.baseInfoBox {
  display: flex;
  flex-direction: row;
  max-width: 500px;
  padding: 12px 12px 4px 12px;
  border-radius: 7px;
  font-size: 12px;
  margin: 20px auto 20px auto;
}
.baseInfoBox img {
  float: left;
  padding-right: 10px;
}
</style>
