<template>
    <div>
        <b-card-group deck class="cardDeck">
          <b-card v-for="card in cards" :key="card.id" :class="getCardClass(card.id)" id="carrd">
              <img v-if="showTick" src="../assets/icons/checkmark.svg"/>
              <p class="subtitle2">{{card.getLockInText()}}</p>
              <h4>{{card.getPrice()}},-</h4>
              <p>/måned</p>
              <BaseButton v-on:BaseButton-clicked="membershipChosen(card.id)" text="Velg" classType="sec"/>
          </b-card>
      </b-card-group>
    </div>
</template>

<script>
export default {
    name: "BaseCardDeck"
}
</script>