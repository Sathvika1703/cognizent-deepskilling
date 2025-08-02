import React, { useState } from 'react';
import BookDetails from './components/BookDetails';
import BlogDetails from './components/BlogDetails';
import CourseDetails from './components/CourseDetails';

function App() {
  const [showBooks, setShowBooks] = useState(true);
  const [showBlogs, setShowBlogs] = useState(true);
  const [showCourses, setShowCourses] = useState(true);

  const books = [
    { id: 101, bname: "Master React", price: 670 },
    { id: 102, bname: "Deep Dive into Angular 11", price: 800 },
    { id: 103, bname: "Mongo Essentials", price: 450 },
  ];

  const sectionStyle = {
    padding: '20px',
    minWidth: '250px',
  };

  const dividerStyle = {
    borderLeft: '2px solid green',
    paddingLeft: '20px',
    marginLeft: '20px'
  };

  return (
    <div style={{ display: 'flex', justifyContent: 'space-around', marginTop: '40px' }}>
      <div style={sectionStyle}>
        {showCourses && <CourseDetails />}
      </div>

      <div style={{ ...sectionStyle, ...dividerStyle }}>
        {showBooks ? <BookDetails books={books} /> : <p>No books available</p>}
      </div>

      <div style={{ ...sectionStyle, ...dividerStyle }}>
        {showBlogs && <BlogDetails />}
      </div>
    </div>
  );
}

export default App;
