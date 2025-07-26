
import React from 'react';
import Post from './Post';

class Posts extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      hasError: false,
    };
  }

  loadPosts() {
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then((response) => response.json())
      .then((data) => this.setState({ posts: data.slice(0, 4) })) // Only first 4 posts
      .catch((error) => {
        console.error('Error fetching posts:', error);
        this.setState({ hasError: true });
      });
  }

  componentDidMount() {
    this.loadPosts();
  }

  componentDidCatch(error, info) {
    alert('An error occurred while rendering the posts.');
    console.error('Error caught by componentDidCatch:', error, info);
  }

  render() {
    if (this.state.hasError) {
      return <p>Something went wrong while loading posts.</p>;
    }

    return (
      <div>
        <h1>Posts</h1>
        {this.state.posts.map((post) => (
          <Post key={post.id} title={post.title} body={post.body} />
        ))}
      </div>
    );
  }
}

export default Posts;
