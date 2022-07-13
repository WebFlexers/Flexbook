import { RouteRecordRaw } from 'vue-router';

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    meta: { transition: 'none' },
    children: [
      { path: '', component: () => import('pages/IndexPage.vue') },
      { path: 'literature_books', component: () => import('pages/BookGenres/LiteratureBooksPage.vue') },
      { path: 'education_books', component: () => import('pages/BookGenres/EducationBooksPage.vue') },
      { path: 'children_books', component: () => import('pages/BookGenres/ChildrenBooksPage.vue') },
      { path: 'history_books', component: () => import('pages/BookGenres/HistoryBooksPage.vue') },
      { path: 'science_books', component: () => import('pages/BookGenres/ScienceBooksPage.vue') },
    ],
  },

  {
    path: '/author/:fullname',
    component: () => import('pages/AuthorPage.vue')
  },

  {
    path: '/book/:title',
    component: () => import('pages/BookPage.vue')
  },

  {
    path: '/checkout',
    component: () => import('pages/CheckoutPage.vue')
  },

  {
    path: '/register',
    component: () => import('pages/RegisterPage.vue')
  },

  {
    path: '/auth',
    component: () => import('pages/LoginPage.vue')
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFoundPage.vue'),
  },
];

export default routes;
