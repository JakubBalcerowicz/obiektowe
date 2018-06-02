    
if(life == 1,2,3)
        {
            stoper = false;
            life3 = GameObject.Find("life3");
            life3.SetActive(false);
        
            UpdateScore();
            youWin = false;
            moveAllowed = true;
            isDead = false;
        
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            anim.SetBool("BallDead", isDead);
        }
