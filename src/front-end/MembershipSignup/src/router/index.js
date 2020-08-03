import Vue from 'vue'
import Router from 'vue-router'
import StartPage from '@/pages/StartPage'
import InstitutionPage from '@/pages/InstitutionPage'
import MembershipPage from '@/pages/MembershipPage'
import PaymentPage from '@/pages/PaymentPage'
import EndPage from '@/pages/EndPage'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'StartPage',
      component: StartPage
    },
    {
      path: '/inst',
      name: 'InstitutionPage',
      component: InstitutionPage
    },
    {
      path: '/form',
      name: 'MembershipPage',
      component: MembershipPage
    },
    {
      path: '/pay',
      name: 'PaymentPage',
      component: PaymentPage
    },
    {
      path: '/end',
      name: 'EndPage',
      component: EndPage
    }
  ]
})
