import * as moment from 'moment';
import { Board } from '../core/models/board.model';
import { Sprint } from '../core/models/sprint.model';
import { TeamMember } from 'src/core/models/team-member';

export const MockBoards: Board[] = [
  {
    ID: 1,
    Name: 'Board 1'
  },
  {
    ID: 2,
    Name: 'Board 2'
  },
  {
    ID: 3,
    Name: 'Board 3'
  },
  {
    ID: 4,
    Name: 'Board 4'
  },
  {
    ID: 5,
    Name: 'Board 5'
  },
  {
    ID: 6,
    Name: 'Board 6'
  },
  {
    ID: 7,
    Name: 'Board 7'
  },
  {
    ID: 8,
    Name: 'Board 8'
  },
  {
    ID: 9,
    Name: 'Board 9'
  },
  {
    ID: 10,
    Name: 'Board 10'
  }
];

export const MockSprints: Sprint[] = [
  {
    ID: 1,
    Name: 'Sprint 1',
    StartDate: moment()
      .add(-16, 'w')
      .toDate(),
    EndDate: moment()
      .add(-14, 'week')
      .toDate(),
    IsComplete: true
  },
  {
    ID: 2,
    Name: 'Sprint 2',
    StartDate: moment()
      .add(-14, 'w')
      .toDate(),
    EndDate: moment()
      .add(-12, 'week')
      .toDate(),
    IsComplete: true
  },
  {
    ID: 3,
    Name: 'Sprint 3',
    StartDate: moment()
      .add(-12, 'w')
      .toDate(),
    EndDate: moment()
      .add(-10, 'week')
      .toDate(),
    IsComplete: true
  },
  {
    ID: 4,
    Name: 'Sprint 4',
    StartDate: moment()
      .add(-10, 'w')
      .toDate(),
    EndDate: moment()
      .add(-8, 'week')
      .toDate(),
    IsComplete: true
  },
  {
    ID: 5,
    Name: 'Sprint 5',
    StartDate: moment()
      .add(-8, 'w')
      .toDate(),
    EndDate: moment()
      .add(-6, 'week')
      .toDate(),
    IsComplete: false
  },
  {
    ID: 6,
    Name: 'Sprint 6',
    StartDate: moment()
      .add(-6, 'w')
      .toDate(),
    EndDate: moment()
      .add(-4, 'week')
      .toDate(),
    IsComplete: false
  },
  {
    ID: 7,
    Name: 'Sprint 7',
    StartDate: moment()
      .add(-4, 'w')
      .toDate(),
    EndDate: moment()
      .add(-2, 'week')
      .toDate(),
    IsComplete: true
  },
  {
    ID: 8,
    Name: 'Sprint 8',
    StartDate: moment()
      .add(-2, 'w')
      .toDate(),
    EndDate: moment()
      .add(0, 'week')
      .toDate(),
    IsComplete: true
  },
  {
    ID: 9,
    Name: 'Sprint 9',
    StartDate: moment()
      .add(0, 'w')
      .toDate(),
    EndDate: moment()
      .add(2, 'week')
      .toDate(),
    IsComplete: false
  },
  {
    ID: 10,
    Name: 'Sprint 10',
    StartDate: moment()
      .add(2, 'w')
      .toDate(),
    EndDate: moment()
      .add(4, 'week')
      .toDate(),
    IsComplete: false
  }
];

export const MockTeamMembers: TeamMember[] = [
  {
    ID: 1,
    Name: 'Member 1'
  },
  {
    ID: 2,
    Name: 'Member 2'
  },
  {
    ID: 3,
    Name: 'Member 3'
  },
  {
    ID: 4,
    Name: 'Member 4'
  },
  {
    ID: 5,
    Name: 'Member 5'
  },
  {
    ID: 6,
    Name: 'Member 6'
  },
  {
    ID: 7,
    Name: 'Member 7'
  },
  {
    ID: 8,
    Name: 'Member 8'
  },
  {
    ID: 9,
    Name: 'Member 9'
  },
  {
    ID: 10,
    Name: 'Member 10'
  },
  {
    ID: 11,
    Name: 'Member 11'
  },
  {
    ID: 12,
    Name: 'Member 12'
  }
];
