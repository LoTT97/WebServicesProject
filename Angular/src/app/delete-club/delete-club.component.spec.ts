import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteClubComponent } from './delete-club.component';

describe('DeleteClubComponent', () => {
  let component: DeleteClubComponent;
  let fixture: ComponentFixture<DeleteClubComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteClubComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteClubComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
