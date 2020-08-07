<template>
  <div class="baseMarketingBox">
    <slot name="content" />
  </div>
</template>

<script>
export default {
  name: "BaseMarketingBox"
};
</script>

<style>
.baseMarketingBox {
  background-color: #f1f3ff;
  padding: 32px;
  margin-bottom: 30px;
}
</style>