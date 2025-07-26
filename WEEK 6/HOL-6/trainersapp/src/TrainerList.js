import React from 'react';
import { Link } from 'react-router-dom';

const TrainerList = ({ trainers }) => {
  return (
    <div>
      <h2>Trainers List</h2>
      <ul>
        {trainers.map(trainer => (
          <li key={trainer.TrainerId}>
            <Link to={`/trainer/${trainer.TrainerId}`}>{trainer.Name}</Link>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default TrainerList;
