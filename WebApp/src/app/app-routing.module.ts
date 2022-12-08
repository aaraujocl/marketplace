import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  
    {
      path: '',
      redirectTo: '/home',
      pathMatch: 'full'
    },
    {
      path: 'home',
      loadChildren: () => import('./offers/offers.module').then(m => m.OffersModule)
    
    },
    {
      path: 'authentication',
      loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule)
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
