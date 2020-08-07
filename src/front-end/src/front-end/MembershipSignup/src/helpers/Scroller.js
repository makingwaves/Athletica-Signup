export class Scroller {

    scrollToEnd(scrollableDiv) {    	
        var container = this.$el.querySelector(scrollableDiv);
        container.scrollTop = container.scrollHeight;
      }

}