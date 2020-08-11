import Vue from 'vue'
import Router from 'vue-router'
import StartPage from '@/pages/StartPage'
import StudentChoicePage from '@/pages/StudentChoicePage'
import InstitutionPage from '@/pages/InstitutionPage'
import MembershipPage from '@/pages/MembershipPage'
import PersonaliaPage from '@/pages/PersonaliaPage'
import SummaryPage from '@/pages/SummaryPage'
import EndPage from '@/pages/EndPage'

Vue.use(Router)

export default new Router({
  scrollBehavior() {
    return { x: 0, y: 0 };
  },
  routes: [
    {
      path: '/',
      name: 'StartPage',
      component: StartPage
    },
    {
      path: '/student',
      name: 'StudentChoicePage',
      component: StudentChoicePage
    },
    {
      path: '/inst',
      name: 'InstitutionPage',
      component: InstitutionPage
    },
    {
      path: '/membership',
      name: 'MembershipPage',
      component: MembershipPage
    },
    {
      path: '/personalia',
      name: 'PersonaliaPage',
      component: PersonaliaPage
    },
    {
      path: '/summary',
      name: 'SummaryPage',
      component: SummaryPage
    },
    {
      path: '/end',
      name: 'EndPage',
      component: EndPage
    }
  ]
})
