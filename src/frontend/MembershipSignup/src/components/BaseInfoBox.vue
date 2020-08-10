<template>
  <div class="baseInfoBox" :style="{'background-color': color}">
    <img src="../assets/icons/info.svg"/>
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
  max-width: 500px;
  padding: 12px 12px 4px 12px;
  border-radius: 7px;
  font-size: 12px;
  margin: 20px auto 20px auto;
}
.baseInfoBox img {
  float: left;
}
</style>