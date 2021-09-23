import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoardNullPermissionComponent } from './board-null-permission.component';

describe('BoardNullPermissionComponent', () => {
  let component: BoardNullPermissionComponent;
  let fixture: ComponentFixture<BoardNullPermissionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BoardNullPermissionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BoardNullPermissionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
