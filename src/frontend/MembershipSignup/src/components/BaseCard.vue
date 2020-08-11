<template>
  <b-card :class="isChosen ? 'mb-2 active' : 'mb-2 card'" @click="setChosen()">
    <slot name="radiobutton"></slot>
    <p class="subtitle2">{{ card.getLockInText() }}</p>
    <h4>{{ card.getPrice() }},-</h4>
    <p>/måned</p>
    <div :key="s.id" v-for="s in card.getInfoSentence()">
      <img v-if="isChosen" id="check" src="../assets/icons/check_white.svg" />
      <img v-else id="check" src="../assets/icons/check_black.svg" />
      <div>{{ s }}</div>
    </div>
  </b-card>
</template>
<script>
import MembershipCard from "@/helpers/MembershipCard.js";

export default {
  name: "BaseCard",
  props: {
    card: MembershipCard,
    isChosen: Boolean,
    setChosen: Function
  }
};
</script>
<style scoped></style>
