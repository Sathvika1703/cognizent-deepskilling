import React from 'react';
import CohortDetails from './components/CohortDetails';

function App() {
  const cohorts = [
    {
      name: 'React Bootcamp',
      trainer: 'Alice',
      status: 'ongoing',
      startDate: '2025-07-01',
      endDate: '2025-08-15'
    },
    {
      name: 'Node.js Mastery',
      trainer: 'Bob',
      status: 'completed',
      startDate: '2025-05-01',
      endDate: '2025-06-15'
    }
  ];

  return (
    <div>
      {cohorts.map((cohort, index) => (
        <CohortDetails key={index} cohort={cohort} />
      ))}
    </div>
  );
}

export default App;
