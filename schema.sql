CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE IF NOT EXISTS users (
    id UUID PRIMARY KEY,
    name VARCHAR (255) NOT NULL,
    username VARCHAR (255) NOT NULL UNIQUE,
    age INT NOT NULL,
    email VARCHAR (255) NOT NULL UNIQUE,
    password VARCHAR (255) NOT NULL
);

-- Create table collections
CREATE TABLE IF NOT EXISTS collections (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4 (),
    name VARCHAR (255) NOT NULL,
    banner VARCHAR (255),
    user_id UUID REFERENCES users (id) ON DELETE CASCADE
);

-- Create table tasks
CREATE TABLE IF NOT EXISTS tasks (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4 (),
    title VARCHAR (255) NOT NULL,
    description TEXT,
    date DATE NOT NULL,
    priority VARCHAR (50),
    deadline DATE,
    collection_id UUID REFERENCES collections (id) ON DELETE CASCADE,
    user_id UUID REFERENCES users (id) ON DELETE CASCADE
);

/*CREATE INDEX idx_user_id ON collections (user_id);
 CREATE INDEX idx_collection_id ON tasks (collection_id);
 CREATE INDEX idx_user_id_tasks ON tasks (user_id);*/